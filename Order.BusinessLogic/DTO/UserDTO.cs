namespace Order.BusinessLogic.DTO
{
    public record  UserDTO(Guid UserId,string?Email,string?UserName,string Gender)
    {
    }
}
