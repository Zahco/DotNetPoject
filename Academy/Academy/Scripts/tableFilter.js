
$("[data-filter-id]").on('keyup', function () {
    $this = $(this);
    $filter = $this.val();
    $id = $this.attr("data-filter-id");
    tableFilter($id, $filter);
});

function tableFilter(id, filter) {
    $table = $("#" + id);
    $url = $table.attr("data-filter-url");
    $.ajax($url + "?filter=" + filter).success(function (response) {
        $table.find("tbody tr").each(function () {
            $tr = $(this);
            if (response.includes($tr.attr("id"))) {
                $tr.show();
            } else {
                $tr.hide();
            }
        });

    });
}
