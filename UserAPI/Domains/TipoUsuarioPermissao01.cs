using System;
using System.Collections.Generic;

namespace UserAPI.Domains
{
    public partial class TipoUsuarioPermissao01
    {
        public TipoUsuarioPermissao01()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
