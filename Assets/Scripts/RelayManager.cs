using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FishNet.Managing;
using FishNet.Transporting.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay.Models;
using Unity.Services.Relay;
using UnityEngine;

public class RelayManager : MonoBehaviour
{
    public static RelayManager Instance;
    
    private void Awake()
    {
        Instance = this;
    }
    //fishnet 네트워크 매니저
    public NetworkManager networkManager;
    
    public async Task<string> StartHostWithRelay(int maxConnections = 5)
    {
        // 릴레이 SDK 초기화
        await UnityServices.InitializeAsync();
        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
        //릴레이 서버 생성
        Allocation allocation = await RelayService.Instance.CreateAllocationAsync(maxConnections);
        
        //가입 코드 생성
        var joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
        
        //FishNet에 들어오는 트래픽이 전부 릴레이 서버로 전달되도록 설정
        FishyUnityTransport transport = networkManager.TransportManager.GetTransport<FishyUnityTransport>();
        transport.SetRelayServerData(new RelayServerData(allocation, "dtls"));
        
        //호스트 시작
        if (networkManager.ServerManager.StartConnection())//호스트 시작 성공
        {
            networkManager.ClientManager.StartConnection();//클라이언트 시작
            return joinCode;
        }
        return null;
    }
    
    public async Task<bool> StartClientWithRelay(string joinCode)
    {
        // 릴레이 SDK 초기화
        await UnityServices.InitializeAsync();
        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
        
        //가입 코드로 릴레이 서버에 접속
        var joinloacation = await RelayService.Instance.JoinAllocationAsync(joinCode: joinCode);
        
        //FishNet에 들어오는 트래픽이 전부 릴레이 서버로 전달되도록 설정
        FishyUnityTransport transport = networkManager.TransportManager.GetTransport<FishyUnityTransport>();
        transport.SetRelayServerData(new RelayServerData(joinloacation, "dtls"));
        
        //클라이언트 시작
        return  !string.IsNullOrEmpty(joinCode) && networkManager.ClientManager.StartConnection();
    }
    
}
