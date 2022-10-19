using AutoMapper;
using Castle.Core.Internal;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO.Endereco;
using FilmesAPI.Models;

namespace FilmesAPI.Services
{
    public class EnderecoService
    {
        private IMapper _mapper;
        private AppDbContext _context;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadEnderecoDTO AdicionaEndereco(AdicionarEnderecoDTO enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            ReadEnderecoDTO enderecoDTO = _mapper.Map<ReadEnderecoDTO>(endereco);

            return enderecoDTO;
        }


        public List<ReadEnderecoDTO>? RecuperaEnderecos()
        {
            List<Endereco> enderecos = _context.Enderecos.ToList();
            List<ReadEnderecoDTO>? retorno = null;

            if (!enderecos.IsNullOrEmpty())
            {
                List<ReadEnderecoDTO> enderecoDTO = _mapper.Map<List<ReadEnderecoDTO>>(enderecos);

                retorno = enderecoDTO;
            }

            return retorno;
        }

        public ReadEnderecoDTO? RecuperaEnderecosPorId(int id)
        {
            ReadEnderecoDTO? retorno = null;

            Endereco? endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco != null)
            {
                ReadEnderecoDTO enderecoDTO = _mapper.Map<ReadEnderecoDTO>(endereco);
                retorno = enderecoDTO;
            }

            return retorno;
        }

        public ReadEnderecoDTO? RecuperaEnderecosPorId(int id, AtualizarEnderecoDTO enderecoDTO)
        {
            ReadEnderecoDTO? retorno = null;
            Endereco? endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco != null)
            {
                _mapper.Map(enderecoDTO, endereco);
                // Quando eu instancio uma variável apontando para um endereço, ela se torna um "ponteiro" daquele endereço
                // Dessa forma, quando endereco recebe o conteúdo de enderecoDTO, quem está recebendo o conteúdo do último é
                // _context.Gerentes onde o ID é igual ao passado por parâmetro. Assim, não é necessário fazer uma
                // declaração formal "_context.Update....."
                _context.SaveChanges();
                retorno = _mapper.Map<ReadEnderecoDTO>(endereco);
            }

            return retorno;
        }

        public bool DeletaEndereco(int id)
        {
            bool retorno = false;

            Endereco? endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco != null)
            {
                _context.Remove(endereco);
                _context.SaveChanges();
                retorno = true;
            }

            return retorno;
        }
    }
}
