using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonSetting : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField UserName;
    [SerializeField] InputField email;
    [SerializeField] InputField password;

    public void LoginSuccess(LoginResult result)
    {
        PhotonNetwork.AutomaticallySyncScene = false;
        PhotonNetwork.GameVersion = "1.0f";
        PhotonNetwork.NickName = PlayerPrefs.GetString("Name");
        PhotonNetwork.LoadLevel("Photon Lobby");
    }
    public void LoginFailure(PlayFabError error)
    {
        NotificationManager.NotificatioinWindow("Login Failed", "There are currently no accounts registered on the server. " + "\n\n Please enter your ID and password correctly.");
    }
    public void SignUpSuccess(RegisterPlayFabUserResult result)
    {
        NotificationManager.NotificatioinWindow("Membership successful", "Congratulation on becoming a mamber." + "\n\n Your email account has been registered on the game server.");
    }
    public void SignUpFailure(PlayFabError error)
    {
        NotificationManager.NotificatioinWindow("Failed to Sign Up", "Membeership registration failed due to a current server error." + "\n\n Please try to register as a member again.");
    }
    public void SignUp()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = email.text,
            Password = password.text,
            Username = UserName.text
        };
        PlayerPrefs.SetString("Name", UserName.text);
        PlayFabClientAPI.RegisterPlayFabUser(request, SignUpSuccess, SignUpFailure);
    }
    public void Login()
    {
        var request = new LoginWithEmailAddressRequest { Email = email.text, Password = password.text, };
        PlayFabClientAPI.LoginWithEmailAddress(request, LoginSuccess, LoginFailure);
    }
}
