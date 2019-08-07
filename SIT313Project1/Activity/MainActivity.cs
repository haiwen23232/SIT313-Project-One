using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Java.Lang;

namespace SIT313Project1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText userNameEditText;
        private EditText passwordEditText;
        private Button loginButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            userNameEditText = FindViewById<EditText>(Resource.Id.login_userName);
            passwordEditText = FindViewById<EditText>(Resource.Id.login_pwd);
            loginButton = FindViewById<Button>(Resource.Id.login_btn);

            this.loginButton.Click += (obj, e) =>
                {
                    string userName = userNameEditText.Text.Trim();
                    string password = passwordEditText.Text;
                    if (string.IsNullOrEmpty(userName))
                    {
                        userNameEditText.Error = "Required";
                    }
                    else if (string.IsNullOrEmpty(password))
                    {
                        passwordEditText.Error = "Required";
                    }
                    else
                    {
                        var localCredential = Application.Context.GetSharedPreferences("Credential", FileCreationMode.Private);

                        // default user name is Jason
                        // default password is Jason123

                        // uncomment following  4 lines to change credential
                        // var credentialEdit = localCredential.Edit();
                        // credentialEdit.PutString("userName", userName);
                        // credentialEdit.PutString("password", password);
                        // credentialEdit.Commit();

                        // check credential
                        string creName = localCredential.GetString("userName", null);
                        string crePwd = localCredential.GetString("password", null);

                        if (!creName.Equals(userName) || !crePwd.Equals(password))
                        {
                            Toast.MakeText(Application.Context, "Wrong user name or password!", ToastLength.Long).Show();
                        }
                        else
                        {
                            Intent intent = new Intent(this, typeof(MenuActivity));
                            this.StartActivity(intent);
                        }
                    }     
                };




        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private class CredentialAsyncTask : AsyncTask
        {
            protected override Object DoInBackground(params Object[] @params)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}