function formatarMoeda(i) {
    var v = i.value.replace(/\D/g, '');
    v = (v / 100).toFixed(2) + '';
    v = v.replace(".", ",");
    v = v.replace(/(\d)(\d{3})(\d{3}),/g, "$1.$2.$3,");
    v = v.replace(/(\d)(\d{3}),/g, "$1.$2,");
    i.value = v;
}

showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    })
}

getListCategorias = (url) => {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: url,
        contentType: "application/json",
        success: function (res) {
            var dados = JSON.parse(res);
            var selectbox = $('#cbCategoria');
            selectbox.find('option').remove();
            $.each(dados, function (i, d) {
                $('<option>').val(d.IdCategoria).text(d.Nome).appendTo(selectbox);
            });
        },
        error: function (xhr) {
            if (xhr.responseText) {
                let response = xhr.responseText;
                alert(response.split("\"errors\":{")[1].split("[\"")[1].split("\"")[0]);
            }
        }
    })
}

jQueryAjaxPost = form => {
    let parametros = {
        "NomeProduto": $("#NomeProduto").val(),
        "IdCategoria": parseInt($("#cbCategoria").val()),
        "Valor": parseFloat($("#Valor").val().replace(".", "").replace(",", ".")),
    }
    try {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: form.action.toString().replace("Produtos", "Api/Produtos"),
            data: JSON.stringify(parametros),
            contentType: "application/json",
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                    window.location.reload();
                }
                else
                    alert(res.message);
            },
            error: function (xhr) {
                if (xhr.responseText) {
                    let response = xhr.responseText;
                    alert(response.split("\"errors\":{")[1].split("[\"")[1].split("\"")[0]);
                }
            }
        })
        return false;
    } catch (ex) {
        console.log(ex)
    }
}

jQueryAjaxPut = form => {
    let parametros = {
        "IdProduto": parseInt($("#IdProduto").val()),
        "NomeProduto": $("#NomeProduto").val(),
        "Valor": parseFloat($("#Valor").val().replace(".", "").replace(",", ".")),
    };
    try {
        $.ajax({
            type: "PUT",
            dataType: "json",
            url: form.action.toString().replace("Produtos", "Api/Produtos/Update"),
            data: JSON.stringify(parametros),
            contentType: "application/json",
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                    window.location.reload();
                }
                else
                    alert(res.message);
            },
            error: function (xhr) {
                if (xhr.responseText) {
                    let response = xhr.responseText;
                    alert(response.split("\"errors\":{")[1].split("[\"")[1].split("\"")[0]);
                }
            }
        })
        return false;
    } catch (ex) {
        console.log(ex)
    }
}

jQueryAjaxDelete = (form, id) => {
    
    if (confirm('Tem certeza que deseja excluir?')) {
        try {
            $.ajax({
                type: 'DELETE',
                url: form.action.toString().replace("Produtos", "Api/Produtos") + "?id=" + id,
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#view-all').html(res.html);
                    window.location.reload();
                },
                error: function (xhr) {
                    if (xhr.responseText) {
                        let response = xhr.responseText;
                        alert(response.split("\"errors\":{")[1].split("[\"")[1].split("\"")[0]);
                    }
                }
            })
        } catch (ex) {
            console.log(ex)
        }
    }
    return false;
}