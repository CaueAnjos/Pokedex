using Spectre.Console;
using Spectre.Console.Extensions;

namespace PokedexCLI.Views;

internal class LoadingView<T> : View<T>
{
    public LoadingView(Task<T> loadingTask)
    {
        LoadingTask = loadingTask;
    }

    public Spinner LoadingSpinner { get; set; } = Spinner.Known.SimpleDots;
    public string LoadingSpinnerStyle { get; set; } = "gray";
    public string LoadingMessage { get; set; } = "[gray]Loading[/]";
    public string CompleteMessage { get; set; } = "[green]Done![/]";
    public Task<T> LoadingTask { get; set; }

    public async Task<T> PrintAsync()
    {
        AnsiConsole.Markup(LoadingMessage);
        var result = await LoadingTask.Spinner(LoadingSpinner, Style.Parse(LoadingSpinnerStyle));
        AnsiConsole.MarkupLine($"  {CompleteMessage}");
        return result;
    }
}

internal static class LoadingViewExtensions
{
    public static LoadingView<T> Loading<T>(this Task<T> task)
    {
        return new LoadingView<T>(task);
    }

    public static LoadingView<T> WithSpinner<T>(this LoadingView<T> view, Spinner spinner)
    {
        view.LoadingSpinner = spinner;
        return view;
    }

    public static LoadingView<T> WithSpinnerStyle<T>(this LoadingView<T> view, string style)
    {
        view.LoadingSpinnerStyle = style;
        return view;
    }

    public static LoadingView<T> WithLoadingMessage<T>(this LoadingView<T> view, string message)
    {
        view.LoadingMessage = message;
        return view;
    }

    public static LoadingView<T> WithCompleteMessage<T>(this LoadingView<T> view, string message)
    {
        view.CompleteMessage = message;
        return view;
    }
}
