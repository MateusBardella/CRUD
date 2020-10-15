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

jQueryAjaxPost = form => {
    let parametros = {
        "Nome": $("#Nome").val()
    }
    try {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: form.action.toString().replace("Categorias", "Api/Categorias"),
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
        "Nome": $("#Nome").val(),
        "IdCategoria": parseInt($("#IdCategoria").val()),
    }
    let url = form.action.toString().replace("Categorias", "Api/Categorias/Update");
    
    try {
        $.ajax({
            type: "PUT",
            dataType: "json",
            url: url,
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
                url: form.action.toString().replace("Categorias", "Api/Categorias") + "?id=" + id,
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