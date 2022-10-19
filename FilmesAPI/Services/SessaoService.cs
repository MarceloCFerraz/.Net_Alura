using AutoMapper;
using Castle.Core.Internal;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO.Sessao;
using FilmesAPI.Models;

namespace FilmesAPI.Services
{
    public class SessaoService
    {
        private IMapper _mapper;
        private AppDbContext _context;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadSessaoDTO AdicionaSessao(AdicionarSessaoDTO sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            ReadSessaoDTO sessaoDTO = _mapper.Map<ReadSessaoDTO>(sessao);

            return sessaoDTO;
        }


        public List<ReadSessaoDTO>? RecuperaSessoes()
        {
            List<Sessao> sessoes = _context.Sessoes.ToList();
            List<ReadSessaoDTO>? retorno = null;

            if (!sessoes.IsNullOrEmpty())
            {
                List<ReadSessaoDTO> cinemaDTO = _mapper.Map<List<ReadSessaoDTO>>(sessoes);

                retorno = cinemaDTO;
            }

            return retorno;
        }

        public ReadSessaoDTO? RecuperaSessoesPorId(int id)
        {
            ReadSessaoDTO? retorno = null;

            Sessao? sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if (sessao != null)
            {
                ReadSessaoDTO sessaoDTO = _mapper.Map<ReadSessaoDTO>(sessao);
                retorno = sessaoDTO;
            }

            return retorno;
        }

        public ReadSessaoDTO? RecuperaSessoesPorId(int id, AtualizarSessaoDTO sessaoDTO)
        {
            ReadSessaoDTO? retorno = null;
            Sessao? sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if (sessao != null)
            {
                _mapper.Map(sessaoDTO, sessao);
                // Quando eu instancio uma variável apontando para um endereço, ela se torna um "ponteiro" daquele endereço
                // Dessa forma, quando sessao recebe o conteúdo de sessaoDTO, quem está recebendo o conteúdo do último é
                // _context.Gerentes onde o ID é igual ao passado por parâmetro. Assim, não é necessário fazer uma
                // declaração formal "_context.Update....."
                _context.SaveChanges();
                retorno = _mapper.Map<ReadSessaoDTO>(sessao);
            }

            return retorno;
        }

        public bool DeletaSessao(int id)
        {
            bool retorno = false;

            Sessao? sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if (sessao != null)
            {
                _context.Remove(sessao);
                _context.SaveChanges();
                retorno = true;
            }

            return retorno;
        }
    }
}
