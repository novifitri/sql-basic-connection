using System;


namespace BasicConnection
{
    class Mahasiswa
    {
        public int Id {get; set;}
        public string Nama {get; set;}
        public string Nim {get; set;}
        public string Alamat {get; set;}
        public int Umur {get; set;}

        public Mahasiswa(){
            
        }
        public Mahasiswa(int id, string nama, string nim, string alamat, int umur){
            this.Id = id;
            this.Nama = nama;
            this.Nim = nim;
            this.Alamat = alamat;
            this.Umur = umur;
        }
    }

}