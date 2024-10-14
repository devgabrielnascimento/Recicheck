using APIRecicheck.Data.Contexts;
using APIRecicheck.Models;
using APIRecicheck.Services;
using APIRecicheck.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace APIRecicheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ColetaController : ControllerBase
    {
        private readonly IColetaService _coletaService;
        private readonly IMapper _mapper;

        public ColetaController(IColetaService condicoesAmbientaisService, IMapper mapper)
        {
            _coletaService = condicoesAmbientaisService;
            _mapper = mapper;
        }
        //[HttpGet]

        //public ActionResult<IEnumerable<ColetaViewModel>> Get()
        //{
        //    var lista = _coletaService.ListarColetas();
        //    var viewModelList = _mapper.Map<IEnumerable<ColetaViewModel>>(lista);


        //    if (viewModelList == null || !viewModelList.Any())
        //    {
        //        return NoContent();
        //    }
        //    else
        //    {
        //        return Ok(viewModelList);
        //    }
        //}

        [HttpGet]
        public ActionResult<IEnumerable<ColetaViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var clientes = _coletaService.ListarModel(pagina, tamanho);
            var viewModelList = _mapper.Map<IEnumerable<ColetaViewModel>>(clientes);

            var viewModel = new ColetaPaginacaoViewModel
            {
                Coletas = viewModelList,
                CurrentPage = pagina,
                PageSize = tamanho
            };


            return Ok(viewModel);
        }

        [HttpGet("{id}")]

        public ActionResult<ColetaViewModel> Get(int id)
        {
            var model = _coletaService.ObterColetaPorID(id);


            if (model == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = _mapper.Map<ColetaViewModel>(model);
                return Ok(viewModel);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] ColetaViewModel coletaViewModel)
        {
            var model = _mapper.Map<ColetaModel>(coletaViewModel);
            _coletaService.CadastrarColeta(model);

            return CreatedAtAction(nameof(Get), new { id = model.coletaId }, model);
        }
        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] int id, [FromBody] ColetaViewModel coletaViewModel)
        {
            if (coletaViewModel.coletaId == id)
            {
                var model = _mapper.Map<ColetaModel>(coletaViewModel);
                _coletaService.AtualizarColeta(model);

                return NoContent();
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult Delete([FromRoute] int id)
        {
                _coletaService.DeletarColeta(id);

                return NoContent();
     

        }



    }
}