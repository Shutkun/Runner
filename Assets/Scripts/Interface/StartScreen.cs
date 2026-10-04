using System;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;

    public override void Close()
    {
        gameObject.SetActive(false);
        ActionButton.interactable = false;
    }

    public override void Open()
    {
        gameObject.SetActive(true);
        ActionButton.interactable = true;
    }

    protected override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}