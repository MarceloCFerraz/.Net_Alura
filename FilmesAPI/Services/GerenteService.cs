using AutoMapper;
using Castle.Core.Internal;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO.Gerente;
using FilmesAPI.Data.DTO.Gerente;
using FilmesAPI.Models;

namespace FilmesAPI.Services
{
    public class GerenteService
    {
        private IMapper _mapper;
        private AppDbContext _context;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadGerenteDTO AdicionaGerente(AdicionarGerenteDTO gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();

            ReadGerenteDTO gerenteDTO = _mapper.Map<ReadGerenteDTO>(gerente);

            return gerenteDTO;
        }


        public List<ReadGerenteDTO>? RecuperaGerentes()
        {
            List<Gerente> gerentes = _context.Gerentes.ToList();
            List<ReadGerenteDTO>? retorno = null;

            if (!gerentes.IsNullOrEmpty())
            {
                List<ReadGerenteDTO> gerenteDTO = _mapper.Map<List<ReadGerenteDTO>>(gerentes);

                retorno = gerenteDTO;
            }

            return retorno;
        }

        public ReadGerenteDTO? RecuperaGerentesPorId(int id)
        {
            ReadGerenteDTO? retorno = null;

            Gerente? gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente != null)
            {
                ReadGerenteDTO gerenteDTO = _mapper.Map<ReadGerenteDTO>(gerente);
                retorno = gerenteDTO;
            }

            return retorno;
        }

        public ReadGerenteDTO? RecuperaGerentesPorId(int id, AtualizarGerenteDTO gerenteDTO)
        {
            ReadGerenteDTO? retorno = null;
            Gerente? gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente != null)
            {
                _mapper.Map(gerenteDTO, gerente);
                // Quando eu instancio uma variável apontando para um endereço, ela se torna um "ponteiro" daquele endereço
                // Dessa forma, quando gerente recebe o conteúdo de gerenteDTO, quem está recebendo o conteúdo do último é
                // _context.Gerentes onde o ID é igual ao passado por parâmetro. Assim, não é necessário fazer uma
                // declaração formal "_context.Update....."
                _context.SaveChanges();
                retorno = _mapper.Map<ReadGerenteDTO>(gerente);
            }

            return retorno;
        }

        public bool DeletaGerente(int id)
        {
            bool retorno = false;

            Gerente? gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente != null)
            {
                _context.Remove(gerente);
                _context.SaveChanges();
                retorno = true;
            }

            return retorno;
        }
    }
}
