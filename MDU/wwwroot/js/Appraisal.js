
var graph;
$(document).ready(function ()
{
    $('#PropertyFilters').on('click', 'input:checkbox', function ()
    {
        SyncCheckboxSelects($(this).closest('.filterGroup'));        
    });
    
    $('#submit').click(function ()
    {
        UpdatePropertyTable();
    });

    $('#runLinearRegression').click(function ()
    {
        GetLinearRegression();
    });

    // init HighCharts
    graph = Highcharts.chart('graph',
    {
        title: {
            text: 'Property Sales'
        },

        subtitle: {
            text: 'Morningside Property Sales'
        },
        xAxis: {
            type: 'datetime',
            dateFormat: '%b \ %y'
        },

        yAxis: {
            //min: 100000,
            //max: 600000,
            title: {
                text: 'Closing Price'
            }
        },
        
        tooltip: {
            formatter: function ()
            {
                var date = new Date(this.x);
                return (date.getMonth() + 1) + ' / ' + date.getFullYear() + '<br>'
                    + '$' + this.y;
            }
        },
        series: [
        {
            name: 'Property Sales',
            data: []
        },
        {
            showInLegend: false,
            name: 'Regression',
            data: []
        }],

        plotOptions: {
            series: {
                
            }
        },

        responsive: {
            rules: [{
                condition: {
                    maxWidth: 500
                },
                chartOptions: {
                    legend: {
                        layout: 'horizontal',
                        align: 'center',
                        verticalAlign: 'bottom'
                    }
                }
            }]
        }

    });

    UpdateGraph();

    InitRangeSliders();

    $('#PropertyFilters').find('.filterGroup').each(function ()
    {
        SyncCheckboxSelects($(this));
    })
});

function InitRangeSliders()
{
    for (var name in filters)
    {
        if (name != 'pool')
        {
            $('#' + name + '-slider').ionRangeSlider(
            {
                type: "double",
                grid: false,
                grid_num: 10,
        
                step: 1,
                values: filters[name].Values
            });
            filters[name]['sliderRef'] = $('#' + name + '-slider').data('ionRangeSlider');
        }
        else
            filters[name]['sliderRef'] = null;
    }
    
}

function SyncCheckboxSelects($filter)
{
    var isDisabled = !$filter.find('input:checkbox').is(':checked');
    var $inputGroup = $filter.children('div').eq(1);
    
    if ($inputGroup.hasClass('form-group'))
    {
        var id = $inputGroup.find('input.slider').prop('id');
        var slider = $('#' + id).data('ionRangeSlider');
        slider.update({ disable: isDisabled });
    } 
    else if ($inputGroup.hasClass('form-check'))    
        $inputGroup.find('input:radio').prop('disabled', isDisabled);
    
}

function UpdatePropertyTable()
{
    var activeFilters = [];
    $('#PropertyFilters').find('.filterGroup').each(function ()
    {
        var $this = $(this);
        if ($this.find('input:checkbox').is(':checked'))
        {
            var filterName = $this.data('filter-shortname')
            if (filters[filterName].sliderRef != null)
            {
                     var   fromId = filters[filterName].Ids[filters[filterName].sliderRef.result.from];
                
                     var   toId = filters[filterName].Ids[filters[filterName].sliderRef.result.to];

                var nextFilter = 
                {
                    'Filter': { 'Id': parseInt($this.data('filter-id'), 10) },
                    'FromValue': { 'Id': fromId },     
                    'ToValue': { 'Id': toId }
                };
                activeFilters.push(nextFilter);
            }
            else
            {
                var nextFilter = 
                {
                    'Filter': { 'Id': parseInt($this.data('filter-id'), 10) },
                    'FromValue': { 'Id': parseInt($('input[name=poolFilter]:checked').val(), 10)}
                };
                
                activeFilters.push(nextFilter);
            }

        }

    });

    var data = {
        'Filters': activeFilters,
        'Page': 1
    }

    $('#waitingOverlay').show();
    $.ajax(
    {
        url: '/appraisal/GetFilteredProperties',
        type: "POST",
        contentType: 'application/json;',
        data: JSON.stringify(data),
        success: function (data)
        {
            $('#propertyTable').find('.tableBody').html(data);
            UpdateGraph();
        },
        error: function (e)
        {
            
        },
        complete: function ()
        {
            $('#waitingOverlay').hide();
        }
    });
}



function UpdateGraph()
{
    var data = [];
    $('.closingPrice').each(function ()
    {
        var price = $(this).data('closing-price');
        var date = new Date($(this).siblings('.closeDate').data('closing-date')).getTime();
        data.push([date, price]);
    });
    graph.series[0].setData(data, true);    
}


function GetLinearRegression()
{
    var activeFilters = [];
    $('#PropertyFilters').find('.filterGroup').each(function ()
    {
        var $this = $(this);
        if ($this.find('input:checkbox').is(':checked'))
        {
            var filterName = $this.data('filter-shortname')
            if (filters[filterName].sliderRef != null)
            {
                var fromId = filters[filterName].Ids[filters[filterName].sliderRef.result.from];
                var toId = filters[filterName].Ids[filters[filterName].sliderRef.result.to];

                var nextFilter = 
                {
                    'Filter': { 'Id': parseInt($this.data('filter-id'), 10) },
                    'FromValue': { 'Id': fromId },     
                    'ToValue': { 'Id': toId }
                };
                activeFilters.push(nextFilter);
            }
            else
            {
                var nextFilter = 
                {
                    'Filter': { 'Id': parseInt($this.data('filter-id'), 10) },
                    'FromValue': { 'Id': parseInt($('input[name=poolFilter]:checked').val(), 10)}
                };
                
                activeFilters.push(nextFilter);
            }
        }
    });

    var data = {
        'Filters': activeFilters,
        'Page': 1
    }

    $('#waitingOverlay').show();
    $.ajax(
    {
        url: '/appraisal/GetLinearRegression',
        type: "POST",
        contentType: 'application/json;',
        data: JSON.stringify(data),
        success: function (data)
        {
            var pts = [[new Date(data.x0).getTime(), data.y0], [new Date(data.x1).getTime(), data.y1]];
            
            graph.series[1].update(
            {
                showInLegend: true,
                name: 'Regression - R2 ' + data.r2.toFixed(3)
            });
            graph.series[1].setData(pts, true); 
        },
        error: function (e)
        {
            
        },
        complete: function ()
        {
            $('#waitingOverlay').hide();
        }
    });
}


'use strict';
Highcharts.createElement('link', {
    href: 'https://fonts.googleapis.com/css?family=Unica+One',
    rel: 'stylesheet',
    type: 'text/css'
}, null, document.getElementsByTagName('head')[0]);

Highcharts.theme = {
    colors: ['#2b908f', '#90ee7e', '#f45b5b', '#7798BF', '#aaeeee', '#ff0066',
        '#eeaaee', '#55BF3B', '#DF5353', '#7798BF', '#aaeeee'],
    chart: {
        backgroundColor: {
            linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
            stops: [
                [0, '#2a2a2b'],
                [1, '#3e3e40']
            ]
        },
        style: {
            fontFamily: '\'Unica One\', sans-serif'
        },
        plotBorderColor: '#606063'
    },
    title: {
        style: {
            color: '#E0E0E3',
            textTransform: 'uppercase',
            fontSize: '20px'
        }
    },
    subtitle: {
        style: {
            color: '#E0E0E3',
            textTransform: 'uppercase'
        }
    },
    xAxis: {
        gridLineColor: '#707073',
        labels: {
            style: {
                color: '#E0E0E3'
            }
        },
        lineColor: '#707073',
        minorGridLineColor: '#505053',
        tickColor: '#707073',
        title: {
            style: {
                color: '#A0A0A3'

            }
        }
    },
    yAxis: {
        gridLineColor: '#707073',
        labels: {
            style: {
                color: '#E0E0E3'
            }
        },
        lineColor: '#707073',
        minorGridLineColor: '#505053',
        tickColor: '#707073',
        tickWidth: 1,
        title: {
            style: {
                color: '#A0A0A3'
            }
        }
    },
    tooltip: {
        backgroundColor: 'rgba(0, 0, 0, 0.85)',
        style: {
            color: '#F0F0F0'
        }
    },
    plotOptions: {
        series: {
            dataLabels: {
                color: '#B0B0B3'
            },
            marker: {
                lineColor: '#333'
            }
        },
        boxplot: {
            fillColor: '#505053'
        },
        candlestick: {
            lineColor: 'white'
        },
        errorbar: {
            color: 'white'
        }
    },
    legend: {
        itemStyle: {
            color: '#E0E0E3'
        },
        itemHoverStyle: {
            color: '#FFF'
        },
        itemHiddenStyle: {
            color: '#606063'
        }
    },
    credits: {
        style: {
            color: '#666'
        }
    },
    labels: {
        style: {
            color: '#707073'
        }
    },

    drilldown: {
        activeAxisLabelStyle: {
            color: '#F0F0F3'
        },
        activeDataLabelStyle: {
            color: '#F0F0F3'
        }
    },

    navigation: {
        buttonOptions: {
            symbolStroke: '#DDDDDD',
            theme: {
                fill: '#505053'
            }
        }
    },

    // scroll charts
    rangeSelector: {
        buttonTheme: {
            fill: '#505053',
            stroke: '#000000',
            style: {
                color: '#CCC'
            },
            states: {
                hover: {
                    fill: '#707073',
                    stroke: '#000000',
                    style: {
                        color: 'white'
                    }
                },
                select: {
                    fill: '#000003',
                    stroke: '#000000',
                    style: {
                        color: 'white'
                    }
                }
            }
        },
        inputBoxBorderColor: '#505053',
        inputStyle: {
            backgroundColor: '#333',
            color: 'silver'
        },
        labelStyle: {
            color: 'silver'
        }
    },

    navigator: {
        handles: {
            backgroundColor: '#666',
            borderColor: '#AAA'
        },
        outlineColor: '#CCC',
        maskFill: 'rgba(255,255,255,0.1)',
        series: {
            color: '#7798BF',
            lineColor: '#A6C7ED'
        },
        xAxis: {
            gridLineColor: '#505053'
        }
    },

    scrollbar: {
        barBackgroundColor: '#808083',
        barBorderColor: '#808083',
        buttonArrowColor: '#CCC',
        buttonBackgroundColor: '#606063',
        buttonBorderColor: '#606063',
        rifleColor: '#FFF',
        trackBackgroundColor: '#404043',
        trackBorderColor: '#404043'
    },

    // special colors for some of the
    legendBackgroundColor: 'rgba(0, 0, 0, 0.5)',
    background2: '#505053',
    dataLabelsColor: '#B0B0B3',
    textColor: '#C0C0C0',
    contrastTextColor: '#F0F0F3',
    maskColor: 'rgba(255,255,255,0.3)'
};

// Apply the theme
Highcharts.setOptions(Highcharts.theme);
