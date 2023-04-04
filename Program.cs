var options = new Supabase.SupabaseOptions
{
	AutoRefreshToken = true,
	AutoConnectRealtime = true
};
//Environment.GetEnvironmentVariable("klW+TgbLxQ3P4bf/2nayH4ev/Xu5ReLzfRWyWN9Ye+xaH+ry0PRT2NgwBCDoMO4SQ1ApajSETXfDX/78DldUeA==")
var supabase = new Supabase.Client("https://lxryqcdezawobgxcnjek.supabase.co", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Imx4cnlxY2RlemF3b2JneGNuamVrIiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTY4MDYwNDQ5NSwiZXhwIjoxOTk2MTgwNDk1fQ.6C1qcETGdEwnlPU7qT6HGLbRPA6i563BtnV5Q4SpBg8", options);
Console.WriteLine("Mi sto connettendo...");
supabase.InitializeAsync();
Console.WriteLine("Connesso...");