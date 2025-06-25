using Cortex.Mediator.Notifications;

namespace pc24395u202312031.API.Shared.Domain.Model.Events;

/// <summary>
/// Representa un evento de dominio en el sistema.
/// 
/// ¿Qué es un evento de dominio?
/// Un evento de dominio es una forma de avisar que algo importante ha pasado en el sistema.
/// Por ejemplo, si un usuario se registra, eso puede ser un evento de dominio llamado "UsuarioRegistrado".
/// Otros componentes del sistema pueden "escuchar" estos eventos y reaccionar, como enviar un correo de bienvenida.
///
/// ¿Qué es el patrón Mediator?
/// El patrón Mediator es una forma de organizar el código para que diferentes partes del sistema puedan comunicarse
/// sin depender directamente unas de otras. En vez de que los componentes se llamen entre sí, le piden al "mediador"
/// que envíe mensajes o eventos. Así, el código es más fácil de mantener y extender.
/// 
/// Esta interfaz sirve para marcar clases como eventos de dominio que pueden ser publicados y manejados por el bus de eventos.
/// Hereda de <see cref="INotification"/> para integrarse con el patrón Mediator.
/// </summary>
/// <remarks>
/// This interface is used to mark classes as domain events that can be published and handled by the event bus.
/// It extends from <see cref="INotification"/> to integrate with the mediator pattern for event handling.
/// </remarks>
public interface IEvent : INotification
{
    // Interfaz vacía, sirve solo como marcador.
}