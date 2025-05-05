namespace SimpleTest;

public class testModel
{
    public string Name { get; set; }
}

public class testPicker : Grid
{
    private Picker pickerInput;

    // Should work, but doesn't
    public static readonly BindableProperty ItemDisplayBindingProperty = BindableProperty.Create(nameof(ItemDisplayBinding), typeof(BindingBase), typeof(testPicker), propertyChanged: (bindable, _, newValue) =>
    {
        if (bindable is testPicker view)
        {
            view.pickerInput.ItemDisplayBinding = (BindingBase)newValue;
        }
    });

    public BindingBase ItemDisplayBinding
    {
        get => (BindingBase)GetValue(ItemDisplayBindingProperty);
        set => SetValue(ItemDisplayBindingProperty, value);
    }

    /*
    // Also should work, but doesn't
    public static readonly BindableProperty ItemDisplayBindingProperty = BindableProperty.Create(nameof(ItemDisplayBinding), typeof(Binding), typeof(testPicker), propertyChanged: (bindable, _, newValue) =>
    {
        if (bindable is testPicker view)
        {
            view.pickerInput.ItemDisplayBinding = (Binding)newValue;
        }
    });

    public Binding ItemDisplayBinding
    {
        get => (Binding)GetValue(ItemDisplayBindingProperty);
        set => SetValue(ItemDisplayBindingProperty, value);
    }

    // Works
    public static readonly BindableProperty ItemDisplayBindingProperty = BindableProperty.Create(nameof(ItemDisplayBinding), typeof(string), typeof(testPicker), propertyChanged: (bindable, _, newValue) =>
    {
        if (bindable is testPicker view)
        {
            view.pickerInput.ItemDisplayBinding = new Binding((string)newValue);
        }
    });
    public string ItemDisplayBinding
    {
        get => (string)GetValue(ItemDisplayBindingProperty);
        set => SetValue(ItemDisplayBindingProperty, value);
    }
    */

    public testPicker(List<testModel> items)
    {
        pickerInput = new() {ItemsSource = items};
        Add(pickerInput);
    }
}

public class TestPage : ContentPage
{
    private testPicker picker;
    public List<testModel> items =
    [
        new() {Name = "Test1"},
        new() {Name = "Test2"},
        new() {Name = "Test3"},
    ];

    public TestPage()
    {
        picker = new testPicker(items) {ItemDisplayBinding = new Binding("Name")};
        picker.ItemDisplayBinding = new Binding("Name");
        Content = new VerticalStackLayout {Children = {picker}};
    }
}
