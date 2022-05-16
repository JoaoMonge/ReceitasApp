namespace FlightPrices;

public class Recipe
{
    private String name;
    private String description;
    private int cookingTime;
    private List<Instruction> instructions;

    public Recipe(string name, string description, int cookingTime, List<Instruction> instructions)
    {
        this.name = name;
        this.description = description;
        this.cookingTime = cookingTime;
        this.instructions = instructions;
    }
}