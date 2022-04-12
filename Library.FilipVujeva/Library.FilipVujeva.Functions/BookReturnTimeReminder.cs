using Library.FilipVujeva.Contracts.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Library.FilipVujeva.Functions
{
    public class BookReturnTimeReminder
    {
        private readonly ILogger _logger;
        private readonly ILibraryNotificationService _service;

        public BookReturnTimeReminder(ILogger logger, ILibraryNotificationService service)
        {
            _logger = logger;
            _service = service;
        }

        [FunctionName("BookRentingReminder")]
        public async Task Run([TimerTrigger("0 0 12 * * *")] TimerInfo myTimer)
        {
            try
            {
                await _service.SendReturnBookNotification();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
