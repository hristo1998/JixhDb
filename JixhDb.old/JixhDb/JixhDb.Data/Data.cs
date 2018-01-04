namespace JixhDb.Data
{
    public class Data
    {
        private static JixhDbContext _context;

        public static JixhDbContext Context
            => _context ?? (_context = new JixhDbContext());
    }
}
