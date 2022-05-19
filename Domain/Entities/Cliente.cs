using Domain.Common;

namespace Domain.Entities;

public class Cliente : AuditableBaseEntity
{
    private int _age;
    
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDay { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Direction { get; set; }
    public int Age
    {
        set => _age = value;
        get
        {
            if (_age <= 0)
            {
                _age = new DateTime(DateTime.Now.Subtract(BirthDay).Ticks).Year - 1;
            }

            return _age;
        }
    }
}