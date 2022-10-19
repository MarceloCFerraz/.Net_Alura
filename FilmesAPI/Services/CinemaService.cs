using AutoMapper;
using Castle.Core.Internal;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO.Cinema;
using FilmesAPI.Models;

namespace FilmesAPI.Services
{
    public class CinemaService
    {
        private IMapper _mapper;
        private AppDbContext _context;

        public CinemaService(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadCinemaDTO AdicionaCinema(AdicionarCinemaDTO cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            ReadCinemaDTO cinemaDTO = _mapper.Map<ReadCinemaDTO>(cinema);

            return cinemaDTO;
        }


        public List<ReadCinemaDTO>? RecuperaCinemas()
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();
            List<ReadCinemaDTO>? retorno = null;

            if (!cinemas.IsNullOrEmpty())
            {
                List<ReadCinemaDTO> cinemaDTO = _mapper.Map<List<ReadCinemaDTO>>(cinemas);

                retorno = cinemaDTO;
            }

            return retorno;
        }

        public ReadCinemaDTO? RecuperaCinemasPorId(int id)
        {
            ReadCinemaDTO? retorno = null;

            Cinema? cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema != null)
            {
                ReadCinemaDTO cinemaDTO = _mapper.Map<ReadCinemaDTO>(cinema);
                retorno = cinemaDTO;
            }

            return retorno;
        }

        public ReadCinemaDTO? RecuperaCinemasPorId(int id, AtualizarCinemaDTO cinemaDTO)
        {
            ReadCinemaDTO? retorno = null;
            Cinema? cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema != null)
            {
                _mapper.Map(cinemaDTO, cinema);
                // Quando eu instancio uma variável apontando para um endereço, ela se torna um "ponteiro" daquele endereço
                // Dessa forma, quando cinema recebe o conteúdo de cinemaDTO, quem está recebendo o conteúdo do último é
                // _context.Gerentes onde o ID é igual ao passado por parâmetro. Assim, não é necessário fazer uma
                // declaração formal "_context.Update....."
                _context.SaveChanges();
                retorno = _mapper.Map<ReadCinemaDTO>(cinema);
            }

            return retorno;
        }

        public bool DeletaCinema(int id)
        {
            bool retorno = false;

            Cinema? cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            
            if (cinema != null)
            {
                _context.Remove(cinema);
                _context.SaveChanges();
                retorno = true;
            }

            return retorno;
        }
    }
}
