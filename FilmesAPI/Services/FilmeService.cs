using AutoMapper;
using Castle.Core.Internal;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO.Cinema;
using FilmesAPI.Data.DTO.Filme;
using FilmesAPI.Models;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        private IMapper _mapper;
        private AppDbContext _context;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadFilmeDTO AdicionaFilme(AdicionarFilmeDTO filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();

            ReadFilmeDTO filmeDTO = _mapper.Map<ReadFilmeDTO>(filme);

            return filmeDTO;
        }


        public List<ReadFilmeDTO>? RecuperaFilmes(int? idade)
        {
            List<Filme> filmes = _context.Filmes.ToList();
            List<ReadFilmeDTO>? retorno = null;

            if (!filmes.IsNullOrEmpty())
            {
                if (idade != null)
                {
                    IEnumerable<Filme> query = from filme in filmes
                                               where filme.ClassificacaoEtaria <= idade
                                               select filme;

                    filmes = query.ToList();
                }

                List<ReadFilmeDTO> filmeDTO = _mapper.Map<List<ReadFilmeDTO>>(filmes);

                retorno = filmeDTO;
            }

            return retorno;
        }

        public ReadFilmeDTO? RecuperaFilmesPorId(int id)
        {
            ReadFilmeDTO? retorno = null;

            Filme? filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
            {
                ReadFilmeDTO filmeDTO = _mapper.Map<ReadFilmeDTO>(filme);
                retorno = filmeDTO;
            }

            return retorno;
        }

        public ReadFilmeDTO? RecuperaFilmesPorId(int id, AtualizarFilmeDTO filmeDTO)
        {
            ReadFilmeDTO? retorno = null;
            Filme? filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
            {
                _mapper.Map(filmeDTO, filme);
                // Quando eu instancio uma variável apontando para um endereço, ela se torna um "ponteiro" daquele endereço
                // Dessa forma, quando filme recebe o conteúdo de filmeDTO, quem está recebendo o conteúdo do último é
                // _context.Gerentes onde o ID é igual ao passado por parâmetro. Assim, não é necessário fazer uma
                // declaração formal "_context.Update....."
                _context.SaveChanges();
                retorno = _mapper.Map<ReadFilmeDTO>(filme);
            }

            return retorno;
        }

        public bool DeletaFilme(int id)
        {
            bool retorno = false;

            Filme? filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
            {
                _context.Remove(filme);
                _context.SaveChanges();
                retorno = true;
            }

            return retorno;
        }
    }
}
