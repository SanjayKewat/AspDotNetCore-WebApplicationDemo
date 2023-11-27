namespace JWT_WebApp.Model
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel()
            {
                UserName="sa",EmaildAddress="sa@gmail.com",Password="1234",GivenName="Sanjay",SurName="kewat", Role="Administrator"
            },
            new UserModel()
            {
                  UserName="sam",EmaildAddress="sam@gmail.com",Password="1234",GivenName="Sanjay",SurName="kewat", Role="Seller"
            },
            new UserModel()
            {
                  UserName="sunny",EmaildAddress="sam@gmail.com",Password="1234",GivenName="Sanjay",SurName="kewat", Role="Buyer"
            }
        };
    }
}