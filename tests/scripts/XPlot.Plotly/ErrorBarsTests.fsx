﻿#r @".\.\bin\Release\XPlot.Plotly.dll"
#r @"..\packages\MathNet.Numerics.3.6.0\lib\net40\MathNet.Numerics.dll"
#load "Credentials.fsx"

// TESTED under CI now


open XPlot.Plotly
open MathNet.Numerics

Plotly.Signin(Credentials.username, Credentials.key)

module BasicSymmetricErrorBars =

    let data =
        Data(
            [
                Scatter(
                    x = [0; 1; 2],
                    y = [6; 10; 2],
                    error_y =
                        ErrorY(
                            ``type`` = "data",
                            array = [1; 2; 3],
                            visible = true
                        )
                )
            ]
        )

    let figure = Figure(data)

    let plotlyResponse = figure.Plot("Basic Symmetric Error Bars Test")

    figure.Show()

module BarChartErrorBars =

    let trace1 =
        Bar(
            x = ["Trial 1"; "Trial 2"; "Trial 3"],
            y = [3; 6; 4],
            name = "Control",
            error_y=
                ErrorY(
                    ``type`` = "data",
                    array = [1; 0.5; 1.5],
                    visible = true
                )
        )
    
    let trace2 =
        Bar(
            x = ["Trial 1"; "Trial 2"; "Trial 3"],
            y = [4; 7; 3],
            name = "Experimental",
            error_y =
                ErrorY(
                    ``type`` = "data",
                    array = [0.5; 1; 2],
                    visible = true
                )
        )

    let data = Data([trace1; trace2])

    let layout = Layout(barmode = "group")

    let figure = Figure(data, layout)

    let plotlyResponse = figure.Plot("Bar Chart with Error Bars Test")

    figure.Show()

module HorizontalErrorBars =

    let data =
        Data(
            [
                Scatter(
                    x = [1; 2; 3; 4],
                    y=[2; 1; 3; 4],
                    error_x =
                        ErrorX(
                            ``type`` = "percent",
                            value = 10.
                        )
                )
            ]
        )

    let figure = Figure(data)

    let plotlyResponse = figure.Plot("Horizontal Error Bars Test")

    figure.Show()

module AsymmetricErrorBars =

    let data =
        Data(
            [
                Scatter(
                    x = [1; 2; 3; 4],
                    y = [2; 1; 3; 4],
                    error_y =
                        ErrorY(
                            ``type`` = "data",
                            symmetric = false,
                            array = [0.1; 0.2; 0.1; 0.1],
                            arrayminus = [0.2; 0.4; 1; 0.2]
                        )
                )
            ]
        )

    let figure = Figure(data)

    let plotlyResponse = figure.Plot("Asymmetric Error Bars Test")

    figure.Show()

module ColoredStyledErrorBars =

    let x_theo = Generate.LinearSpaced(100, -4., 4.) // np.linspace(-4, 4, 100)
    let sincx =  Array.map Trig.Sinc x_theo

    let x = [-3.8; -3.03; -1.91; -1.46; -0.89; -0.24; -0.0; 0.41; 0.89; 1.01; 1.91; 2.28; 2.79; 3.56]
    let y = [-0.02; 0.04; -0.01; -0.27; 0.36; 0.75; 1.03; 0.65; 0.28; 0.02; -0.11; 0.16; 0.04; -0.15]

    let trace1 =
        Scatter(
            x = x_theo,
            y = sincx,
            name = "sinc(x)"
        )

    let trace2 =
        Scatter(
            x = x,
            y = y,
            mode = "markers",
            name = "measured",
            error_y=
                ErrorY(
                    ``type`` = "constant",
                    value = 0.1,
                    color = "#85144B",
                    thickness = 1.5,
                    width = 3.,
                    opacity = 1.
                ),
            error_x =
                ErrorX(
                    ``type`` = "constant",
                    value = 0.2,
                    color = "#85144B",
                    thickness = 1.5,
                    width = 3.,
                    opacity = 1.
                ),
            marker =
                Marker(
                    color = "#85144B",
                    size = 8.
                )
        )

    let data = Data([trace1; trace2])

    let figure = Figure(data)

    let plotlyResponse = figure.Plot("Colored and Styled Error Bars Test")

    figure.Show()

module ErrorBarsPercentageYValue =

    let data =
        Data(
            [
                Scatter(
                    x = [0; 1; 2],
                    y = [6; 10; 2],
                    error_y =
                        ErrorY(
                            ``type`` = "percent",
                            value = 50.,
                            visible = true
                        )
                )
            ]
        )

    let figure = Figure(data)

    let plotlyResponse = figure.Plot("Error Bars as a Percentage of the y-Value Test")

    figure.Show()

module AsymmetricErrorBarsConstantOffset =

    let data =
        Data(
            [
                Scatter(
                    x = [1; 2; 3; 4],
                    y = [2; 1; 3; 4],
                    error_y =
                        ErrorY(
                            ``type`` = "percent",
                            symmetric = false,
                            value = 15.,
                            valueminus = 25.
                        )
                )
            ]
        )

    let figure = Figure(data)

    let plotlyResponse = figure.Plot("Asymmetric Error Bars with a Constant Offset Test")

    figure.Show()
