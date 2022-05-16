namespace FlightPrices;

public class Recipe
{
    private String name;
    private int id;
    private String description;
    private int cookingTime;
    private List<Instruction> instructions;

    public Recipe(String name, String description, int cookingTime, List<Instruction> instructions, int id)
    {
        this.name = name;
        this.id = id;
        this.description = description;
        this.cookingTime = cookingTime;
        this.instructions = instructions;
    }

    public String Name => name;

    public int Id => id;

    public String Description => description;

    public int CookingTime => cookingTime;

    public List<Instruction> Instructions => instructions;

    /*
     * Percorrer as instrucções e mostrar toda a lista
     * 
     */
    public void mostrarInstrucoes()
    {
        Console.WriteLine("1º - instrucao");
        Console.WriteLine("2º - instrucao");
        
    }
    
    /**
     * Mostrar o nome e descricao da receita
     */
    public void mostrarNomeDescricao()
    {
        Console.WriteLine("Nome e descricao");

    }

    /*
     * Mostrar o tempo que demora a fazer
     */
    public void mostrarTempoEstimado()
    {
        Console.WriteLine("Tempo");
    }
}