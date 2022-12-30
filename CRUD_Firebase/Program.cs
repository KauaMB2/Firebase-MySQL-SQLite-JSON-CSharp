using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;

namespace Firebase{
    public class Commands{
        private static IFirebaseConfig config = new FirebaseConfig(){
            AuthSecret="zXLrjwMjz6ZthqcM9fwFkyR77oDLuw5nO5WKaQr3",
            BasePath="https://hackathonete-default-rtdb.firebaseio.com/"
        };
        private static IFirebaseClient client = new FirebaseClient(config);
        public static void Create(int targetId,string Nome,string Email){
            Usuario novoUsuario = new Usuario{//Create de object
                Id=targetId,
                Nome=Nome,
                Email=Email
            };
            client.Set($"Users/{targetId}", novoUsuario);//Create the User/{targetId} path and add the newUser object in this path 
        }

        public static void Delete(int targetId){
            client.Delete($"Users/{targetId}");//Delete the path targetId
        }

        public static List<Usuario> Read(string Nome){
            FirebaseResponse userData;
            List<Usuario> finalList=new List<Usuario>();
            List<Usuario> listUserObject=new List<Usuario>();
            userData=client.Get("Users/");
            listUserObject=userData.ResultAs<List<Usuario>>();
            if(Nome==""){
                return listUserObject;
            }else{
                foreach(Usuario user in listUserObject){
                    if((user.Nome).IndexOf(Nome)!=-1){
                        finalList.Add(user);
                    }
                }
            }
            return finalList;
        }

        public static void Update(int targetId,string Nome,string Email){
            Usuario novoUsuario = new Usuario{//Create de object
                Id=targetId,
                Nome=Nome,
                Email=Email
            };
            client.Update($"Users/{targetId}", novoUsuario);//Update the User/{targetId} path with the updatedUser data 
        }

        public static void Main(){
            Create(1,"Kauã","emaildoKaua@kaua.com");
            Create(2,"Jão","emaildojao@jao.com");
            List<Usuario> resultadoPesquisa;
            resultadoPesquisa=Read("J");
            foreach(Usuario user in resultadoPesquisa){
                Console.WriteLine(user.Nome);
            }
            Update(2,"Pedro","emaildoPedro@Pedro.com");
            resultadoPesquisa=Read("P");
            foreach(Usuario user in resultadoPesquisa){
                Console.WriteLine(user.Nome);
            }
            Delete(2);
        }
    }
    public class Usuario{//It creates the object that will be sended to DB
        public int Id;
        public string Nome;
        public string Email;
    }
}
