function DeleteUser(userId) {
    Swal.fire({
        title: 'Kaydı silmek istediğinizden emin misiniz? ',
        showCancelButton: true,
        confirmButtonText: 'Sil',
        cancelButtonText: 'İptal',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/User/DeleteUser?id=" + userId,
            }).done(function (response) {
                Swal.fire({
                    icon: 'success',
                    title: 'Başarıyla silindi...'
                }).then((result) => {
                    window.location.href = "/User/Index/";
                })
            })
            Swal.fire('Kullanıcı silindi!', '', 'success')
        } else if (result.isDenied) {
            window.location.href = "/User/Index/";
        }
    })
}
