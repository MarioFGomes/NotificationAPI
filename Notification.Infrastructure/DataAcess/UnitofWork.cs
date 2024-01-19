using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Infrastructure.DataAcess {
    internal class UnitofWork: IDisposable, IUnitofWork {

        private readonly NotificationContext _contexto;
        private bool _disposed;

        public UnitofWork(NotificationContext context) {
            _contexto = context;
        }

        public async Task Commit() {
            await _contexto.SaveChangesAsync();
        }

        public void Dispose() {
            Dispose(true);
        }

        public void Dispose(bool dispose) {
            if (!_disposed && dispose) {
                _contexto.Dispose();
            }

            _disposed = true;
        }
    }
}
