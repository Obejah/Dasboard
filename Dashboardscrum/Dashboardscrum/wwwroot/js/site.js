<script>
    $(document).ready(function () {
        $("#selectedOption").change(function () {
            var selectedValue = $("#selectedOption").val();
            $.ajax({
                type: "POST",
                url: "/YourPage/GetData",
                data: { option: selectedValue },
                success: function (data) {
                    // Your code to update other data based on the returned data
                }
            });
        });
     });
</script>