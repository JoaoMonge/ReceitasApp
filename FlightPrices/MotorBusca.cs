
using Newtonsoft.Json;

using System.Text.Json.Nodes;

namespace FlightPrices;

public class MotorBusca
{

    public List<Recipe> recipes = new List<Recipe>();


    public async Task pesquisar(String recipe)
    {
        var client = new HttpClient();
        
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=20&tags=under_30_minutes&size=25&q=" +
                                 recipe),
            Headers =
            {
                { "X-RapidAPI-Host", "tasty.p.rapidapi.com" },
                { "X-RapidAPI-Key", "2c919a96d7msh4b3c8f542ec9108p1b1e5fjsn5c0f938ee222" },
            },
        };
        
        
        using (var response = await client.SendAsync(request))
        {
            
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            
            dynamic json = JsonConvert.DeserializeObject(body);
            Console.WriteLine( json );
      
           
            var list = json.results;
            //Console.WriteLine(list);
            foreach (var item in list)
            {
                Console.WriteLine("Nome:");
                Console.WriteLine(item.name);
                Console.WriteLine("Descricao: ");
                Console.WriteLine(item.description);
                Console.WriteLine("Tempo:");
                Console.WriteLine(item.cook_time_minutes);
                Console.WriteLine("Instrucoes:");
                
                List<Instruction> instructions = new List<Instruction>();
                foreach (var inst in item.instructions)
                {
                    Console.WriteLine( inst.display_text);
                    Instruction i = new Instruction(inst.display_text);
                    instructions.Add(i);
                }
                
                Recipe r = new Recipe(item.name, item.description, item.cook_time_minutes, instructions);
            }
            
            
        }

    }
}
