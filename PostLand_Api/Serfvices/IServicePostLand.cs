using PostLand_Api.Model;

namespace PostLand_Api.Serfvices
{
    public interface IServicePostLand
    {
        Task <Authmodel> RigsterAsync(RigsterModel  model);
        Task<Authmodel> SignInAsync(SignIn model);
        Task<string> AddRoleAsync(AddRole model);
    }
}
