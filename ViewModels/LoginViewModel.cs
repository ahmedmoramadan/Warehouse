namespace WarehouseProject.ViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
