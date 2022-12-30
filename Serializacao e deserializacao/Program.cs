using Newtonsoft.Json;
using System.IO;
public class Processo{
    public static void Serializacao(Dados novoRegistro){
        //Serialization is the conversion of a object values into a flow binary data, that is, a file writing.
        var dadosJson_Serializado=JsonConvert.SerializeObject(novoRegistro);
        File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory+@"\Registros\RegistrosJson.json",dadosJson_Serializado);
    }
    public static Dados Deserializacao(){
        //Deserialization is the conversion of binary values into a object, that is, a file reading.
        string json=File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory+@"\Registros\RegistrosJson.json");
        Dados obj_Deserializado=JsonConvert.DeserializeObject<Dados>(json);
        return obj_Deserializado;
    }
    public static void Main(){
        Dados obj=Deserializacao();
        Console.WriteLine("Escreva um novo nome: ");
        string novoNome=Console.ReadLine();
        obj.Id=0;
        obj.Nome=novoNome;
        obj.Trabalha=false;
        Serializacao(obj);
    }
}
public class Dados{
    public int Id {get;set;}
    public string Nome {get;set;}
    public bool Trabalha {get;set;}
}