
using Newtonsoft.Json;

using System.Text.Json.Nodes;

namespace FlightPrices;

public class MotorBusca
{
    

    public List<Recipe> recipes = new List<Recipe>();


    public async Task pesquisar(String recipe)
    {
        //Criar um cliente HTTP para obter fazer pedidos
        var client = new HttpClient();
        
        //Criar o pedido do tipo GET
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
        
        
        //Fazer o pedido à internet
        using (var response = await client.SendAsync(request))
        {
            //Verificar se a resposta não têm erros
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            
            //Converter a string em Json
            dynamic json = JsonConvert.DeserializeObject(body);
      
           
            //Percorrer o JSON dos dados
            var list = json.results;
            //Console.WriteLine(list);
            foreach (var item in list)
            {
                /*
                Console.WriteLine(item.id);
                Console.WriteLine("Nome:");
                Console.WriteLine(item.name);
                Console.WriteLine("Descricao: ");
                Console.WriteLine(item.description);
                Console.WriteLine("Tempo:");
                Console.WriteLine(item.cook_time_minutes);
                Console.WriteLine("Instrucoes:");
                */
                
                
                //Criar a lista de instruções para uma das receitas
                List<Instruction> instructions = new List<Instruction>();
                foreach (var inst in item.instructions)
                {
                    Instruction i = new Instruction(String.Format("{0}", inst.display_text));
                        instructions.Add(i);
                }
                
                //Guardar a receita na lista de receitas
                Recipe r = new Recipe(String.Format("{0}",item.name),String.Format("{0}",item.description), Int32.Parse(String.Format("{0}",item.cook_time_minutes)), instructions, Int32.Parse(String.Format("{0}",item.id))); 
                recipes.Add(r);
                
            }
        }

       
    }
    
    /*
     * Mostra a lista de todas as receitas encontradas
     */
    public void listarReceitas()
    {
        foreach (var rec in recipes)
        {
            Console.WriteLine("id: {0} name: {1}",rec.Id,rec.Name);
        }
        
    }

    /*
     * Devolve uma receita que tenha este id ou null caso não exista nenhuma que corresponda ao id procurado
     */
    public Recipe getById(int id)
    {
        foreach (var rec in recipes)
        {
            if (rec.Id == id)
            {
                return rec;
            }
        }

        return null;
    }
}
