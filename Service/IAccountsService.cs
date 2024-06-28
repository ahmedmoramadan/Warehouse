namespace WarehouseProject.Service
{
    public interface IAccountsService
    {
        Task Register1(int id);
        Task Register3(int id);
        Task Register2(int id);
        Task Register4();
        Task Register5();
        Task Register6();
        Task LoginManager1();
        Task LoginManager2();
        Task Logout();
    }
}
