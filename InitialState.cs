using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayerGameOfLife.Models;

public class InitialState
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Stored in DB as "1,2;3,4;5,6;"
    public string State { get; set; } = string.Empty;

    [NotMapped]
    public List<(int x, int y)> Values
    {
        get
        {
            var result = new List<(int x, int y)>();
            if (string.IsNullOrWhiteSpace(State)) return result;

            foreach (var part in State.Split(';', StringSplitOptions.RemoveEmptyEntries))
            {
                var nums = part.Split(',');
                if (nums.Length == 2 &&
                    int.TryParse(nums[0], out int x) &&
                    int.TryParse(nums[1], out int y))
                {
                    result.Add((x, y));
                }
            }
            return result;
        }
    }

    // Call this before saving to DB to serialize Values → State
    public void SerializeValues(List<(int x, int y)> values)
    {
        State = string.Join("", values.Select(v => $"{v.x},{v.y};"));
    }
}
