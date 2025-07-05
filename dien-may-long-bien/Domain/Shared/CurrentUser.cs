using DienMayLongBien.Domain.Entities;

namespace DienMayLongBien.Domain.Shared;

public class CurrentUser
{
    private User? _user;

    public User? User => _user;

    public void SetUser(User user)
    {
        _user = user;
    }

    public void ClearUser()
    {
        _user = null;
    }

    public bool IsAuthenticated => _user != null;
}
