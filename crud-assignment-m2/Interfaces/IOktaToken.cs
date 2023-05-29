    using System;
    namespace crud_assignment_m2.Interfaces
    {
        public interface IOktaToken
            {
                Task<string> GetToken();

            }
    }

