using System;
using System.Collections.Generic;

namespace UserAPI.Domains
{
    public partial class TipoUsuarioPermissao02
    {
        public TipoUsuarioPermissao02()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
