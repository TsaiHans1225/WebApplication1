const { createApp } = Vue

createApp({
    data() {
        return {
            message2: 'Hello',
            test: '安安你好ㄇ',
            arr1: [1, 2, 3]
        }
    },
    methods: {
        ajax() {
            _this = this;
            let arr = [];
            $.ajax(
                {
                    type: "GET",
                    url: "/Home/Index3",
                    data: {
                        Id: 9999,
                        Sal: 87,
                        Name: '安安安',

                    },
                    dataType: "json",
                    success: function (response) {
                        //console.log(response)
                        _this.test = response[0].name;
                        response.forEach(function (item) {
                            //console.log(item);
                            arr.push(item);
                        })
                        console.log(arr);
                        _this.arr1 = arr;
                    },
                    error: function (thrownError) {
                        console.log(thrownError);
                    }
                });
        },
        ajax2() {
            _this = this;
            let arr = [];
            $.ajax(
                {
                    type: "GET",
                    url: "/Home/Index4",
                    data: {

                    },
                    dataType: "json",
                    success: function (response) {
                        console.log(response)
                        response.forEach(function (item) {
                            console.log(item);
                            arr.push(item);
                        })
                        _this.arr1 = arr;
                        console.log(_this.arr1);
                    },
                    error: function (thrownError) {
                        console.log(thrownError);
                    }
                });
        },
    },
    mounted() {
        this.ajax();
    },
    created() {

    },
    beforeMount() {

    },

}).mount('#app')