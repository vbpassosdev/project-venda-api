using ACBrLib.NFSe;
using project_venda_api.Data.Context;
using ACBrLib.Core;
using System.Text;


namespace project_venda_api.Service
{
    public class NFSeService
    {
        private readonly AppDbContext _context;

        public NFSeService(AppDbContext context)
        {
            _context = context;
        }

        public string GerarNfse(int nfseId)
        {
            var basePath = AppContext.BaseDirectory;
            var iniConfig = Path.Combine(basePath, "ACBrNFSe.ini");
            var iniRps = Path.Combine(basePath, "RPS.ini");
            var pastaSaida = Path.Combine(basePath, "NFSe");

            if (!Directory.Exists(pastaSaida))
                Directory.CreateDirectory(pastaSaida);

            using var nfse = new ACBrNFSe();

            nfse.ConfigLer(iniConfig);

            nfse.ConfigGravarValor(ACBrSessao.Principal, "UF", "SP");
            nfse.ConfigGravarValor(ACBrSessao.Principal, "Ambiente", "2");
            nfse.ConfigGravarValor(ACBrSessao.NFSe, "SSLType", "5"); // Windows Crypt
            nfse.ConfigGravarValor(ACBrSessao.NFSe, "SSLCryptLib", "1");
            nfse.ConfigGravarValor(ACBrSessao.NFSe, "SSLHttpLib", "2");
            nfse.ConfigGravarValor(ACBrSessao.NFSe, "SSLXmlSignLib", "4");
            nfse.ConfigGravarValor(ACBrSessao.NFSe, "Municipio", "3537107");
            nfse.ConfigGravarValor(ACBrSessao.NFSe, "CodigoMunicipio", "3537107"); 
            nfse.ConfigGravarValor(ACBrSessao.NFSe, "Provedor", "Fiorilli");
            nfse.ConfigGravarValor(ACBrSessao.NFSe, "NumeroSerie", "01f47f7c107720fc69005c9753247d21");
            nfse.ConfigGravar();

            var ini = $@"
                    [Principal]
                    TipoResposta=0
                    CodificacaoResposta=0
                    LogNivel=0
                    LogPath=
                    UF=SP
                    Ambiente=2

                    [NFSe]
                    Municipio=3537107
                    Provedor=Fiorilli
                    NumeroSerie=01f47f7c107720fc69005c9753247d21

                    [RPS]
                    Numero={nfseId}
                    Serie=UNICA
                    Tipo=1
                    DataEmissao={DateTime.Now:dd/MM/yyyy}

                    [Prestador]
                    CNPJ=00000000000000
                    InscricaoMunicipal=123456

                    [Tomador]
                    CPFCNPJ=00000000000
                    RazaoSocial=Cliente Teste

                    [Servico]
                    ItemListaServico=0107
                    CodigoMunicipio=3537107
                    Discriminacao=Servico de teste
                    ValorServicos=100.00
                    Aliquota=2.00
                    ";

            File.WriteAllText(iniRps, ini, Encoding.UTF8);

            nfse.LimparLista();
            nfse.CarregarINI(iniRps);

            var xml = nfse.ObterXmlRps(0);
            var caminhoXml = Path.Combine(pastaSaida, $"RPS_{nfseId}.xml");

            File.WriteAllText(caminhoXml, xml, Encoding.UTF8);

            return caminhoXml;
        }
    }
}