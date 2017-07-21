var aplicacion = "Velez Blog";

var articulos = [{ "titulo": 'Empatamos', "texto": "Empatamos con el cervecero...", destacado: true, img: '/Content/images/quilmes.jpg' },
{ "titulo": 'Ganamos el "clásico"', "texto": "Vélez le ganó a Tigre de local...", destacado: true, img: '/Content/images/tigre.jpg' },
{ "titulo": 'Otra derrota en casa', "texto": "Vélez perdió con Belgrano de local...", destacado: true, img: '/Content/images/belgrano.jpg' },
{ "titulo": 'Otra derrota de visitante', "texto": "Vélez perdió con Lanus.", destacado: true, img: '/Content/images/velezlanus.jpg' },
{ "titulo": 'Otra noticia positiva', "texto": "Vélez.", destacado: false, img: null },
{ "titulo": 'Otra noticia positiva', "texto": "Vélez.", destacado: false, img: null },
{ "titulo": 'Otra noticia positiva', "texto": "Vélez.", destacado: false, img: null },
{ "titulo": 'Otra noticia positiva', "texto": "Vélez.", destacado: false, img: null },
{ "titulo": 'Otra noticia positiva', "texto": "Vélez.", destacado: false, img: null },
{ "titulo": 'Otra noticia positiva', "texto": "Vélez.", destacado: false, img: null },
{ "titulo": 'Otra noticia positiva', "texto": "Vélez.", destacado: false, img: null },
{ "titulo": 'Otra noticia positiva', "texto": "Vélez.", destacado: false, img: null }];


/*function darBienvenida(){
    alert("Bienvenido al Blog de Velez!!!");
}
$('#ingresar').on('click', darBienvenida);*/

$(document).on('ready', function () {

    /*
    $('#ingresar').on('click', function () {

        //$('#iniciar').hide();
        $('#iniciar').addClass('hide');
        $('.menuUsuario').removeClass('hide');
        $('.agregarArticulo').removeClass('hide');
        //le permitimos eliminar los artículos
        $(".articulo .close").removeClass("hide");

        var email = $('#loginEmail').val();
        //$('.usuario span:first').text(email);
        $('#nombreUsuario').text(email);

        alert("Bienvenido al Blog de Velez!!!");
    });

    $("#salir").on('click', function () {
        $(".menuUsuario").addClass("hide");
        $("#iniciar").removeClass("hide");
        $(".articulo .close").addClass("hide");
    });
    */

    $("body").on('click', ".articulo .close", function () {
        //acá el this es el botón al que le hice click.
        $(this).parent().remove();
    });

    /*
    $("#agregarArticulo").on('click', function () {

        var titulo = $('#tituloArticulo').val();
        var texto = $('#textoArticulo').val();

        $("#articulos").prepend('<div class="articulo col-xs-6 col-md-4">' +
                    '<button href="#" class="close" aria-label="Close"><span aria-hidden="true">&times;</span></button>' +
                    '<h3>' + titulo + '</h3>' +
                    '<p>' + texto + '</p>' +
                    '</div>');
    });
    */

    //cargar los artículos!!
    /*
    for(var i = 0;i < articulos.length;i++)
    {
        var articulo = articulos[i];
        $("#articulos").append('<div class="articulo col-xs-6 col-md-4">' +
                    '<button href="#" class="close hide" aria-label="Close"><span aria-hidden="true">&times;</span></button>'+
                    '<h3>' + articulo.titulo + '</h3>' +
                    '<p>' + articulo.texto +'</p>' +
                    '</div>');
    }*/

    //EL AGREGADO DE ARTÍCULOS AHORA LO HACEMOS EN SERVER
    //esto mismo podría estar en un while
    /*
    var i = 0;
    while (i < articulos.length) {
        var articulo = articulos[i];

        if (articulo.destacado) {
            var clase = '';
            var cantidadExistentes = $(".carousel-inner").children().length;
            if (cantidadExistentes == 0) {
                clase = 'active';
            }

            $(".carousel-inner").append('<div class="item ' + clase + '">' +
					'<img class="img-responsive" src="' + articulo.img + '" alt="...">' +
					'<div class="carousel-caption">' +
						'<div class="cabeceraNoticia">' +
							'<h3>' + articulo.titulo + '</h3>' +
							'<p>' + articulo.texto + '</p>' +
						'</div>' +
					'</div>' +
				'</div>');

            //agrego el indicador
            $(".carousel-indicators").append(
                '<li data-target="#carousel-example-generic" data-slide-to="'
                    + cantidadExistentes + '" class="' + clase + '"></li>'
            );

        } else {
            $("#articulos").append('<div class="articulo col-xs-6 col-md-4">' +
                    '<button href="#" class="close hide" aria-label="Close"><span aria-hidden="true">&times;</span></button>' +
                    '<h3>' + articulo.titulo + '</h3>' +
                    '<p>' + articulo.texto + '</p>' +
                    '</div>');
        }

        i++;
    }
    */

    //animación de links
    $(".linkCopado").on("click", function () {
        var marcador = $(this).data("pos");
        var posicionDelMarcador = $(marcador).offset().top;
        $("html,body").stop().animate({ scrollTop: (posicionDelMarcador - 50) }, 1000);
    });

    //obtener clima de CABA
    $('#climaActual').text('Consultando clima en la ciudad...');
    $.ajax('http://api.openweathermap.org/data/2.5/weather?id=3433955&appid=b8c4ffcd65abed88f5ba857acde3cbd8',
    {
        dataType: 'jsonp', //para llamadas a otros servidores
        contentType: 'application/json',
        success: function (response) {
            var clima = response.weather[0];
            $('#climaActual').text(clima.main + ': ' + clima.description);
            $('#climaActual').append('<img src="http://openweathermap.org/img/w/' + clima.icon + '.png">');
        },
        error: function (request, errorType, errorMessage) {
            alert('dio error');
        }
    });
});


