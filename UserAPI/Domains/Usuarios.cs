using System;
using System.Collections.Generic;

namespace UserAPI.Domains
{
    public partial class Usuarios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? TipoUsuarioPermissao { get; set; }
        public int? TipoUsuarioPermissaoAcesso { get; set; }

        public TipoUsuarioPermissao02 TipoUsuarioPermissaoAcessoNavigation { get; set; }
        public TipoUsuarioPermissao01 TipoUsuarioPermissaoNavigation { get; set; }
    }
}
