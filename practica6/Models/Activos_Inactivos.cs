namespace Modelos
{  
    public class Activos_Inactivos {
        public int Activos {get;set;}
        public int Inactivos{get;set;}

        public Activos_Inactivos(int Activos,int Inactivos){
            this.Activos = Activos;
            this.Inactivos = Inactivos;
        }
        public Activos_Inactivos(){}
    }
}