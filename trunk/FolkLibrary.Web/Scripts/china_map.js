function chinaMap(targetId) {
    // 基于准备好的dom，初始化echarts实例
    var myChart = echarts.init(document.getElementById(targetId));
    var option = optionConfig();
    myChart.on("click", function (param) {
        alert(param.name);
        
    })
    // 使用刚指定的配置项和数据显示图表。
    myChart.setOption(option);
}

function optionConfig() {
    return option = {
        tooltip: {
            trigger: 'item',
            formatter: function (params) {
                return "可配置";
            }
        },
        series: [{
            type: 'map',
            mapType: 'china',
            label: {
                normal: {
                    show: true
                },
                emphasis: {
                    show: true
                }
            },
            markPoint: {
                symbol: 'pin',
                symbolSize: 20,
                label: {
                    normal: {
                        show: true,
                        formatter: function (d) {
                            return d.name
                        }
                    }
                },
            }
        }]
    };
}

