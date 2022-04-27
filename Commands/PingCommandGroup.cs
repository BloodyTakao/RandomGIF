using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace BloodyTakao.RandomGif.Commands;

// Commands defined here can be stateless.
// This also means the IDE will easily be triggered to suggest turning your commands into static methods, which would break 'em. 
#pragma warning disable CA1822



/*
 * This is a sample command group, with some commands.
 *
 * When defining a command group, your class must follow the following constraints:
 *   - Must be public, non-static, and well defined
 *   - Must inherit from BaseCommandGroup
 *   - Must have a [Group("<group-name>")] attribute
 *
 * You can use any constructor parameters you want, following Dependency Injection (DI) conventions.
 */
[Group("hug"), Description("Sends a random hug gif")]
public class PingCommandGroup : BaseCommandModule
{
	/*
	 * When defining a command, your method must follow the following constraints:
	 *   - Must be public, non-static, and well defined
	 *   - Must have a [Command] attribute
	 *   - Must contain a first parameter of type CommandContext
	 */



	/// <summary>
	/// A simple echo command which will respond with the message sent.
	/// </summary>
	/// <remarks>
	/// Invoked using "==sample ping echo &lt;message&gt;"
	/// </remarks>
	[GroupCommand, Description("construction of awnser")]
	public async Task HugAsync(CommandContext ctx, [RemainingText] DiscordUser user)
	{
		//step 1 : takes a random gif link for hug out of list
		//step 2 : constructs message in "Author hugs User "random selected link""
		//step 3 : sends message

		string gifLink = "https://tenor.com/view/hug-cats-gif-24875555";

		await ctx.RespondAsync($"{ctx.User.Mention} hugs {user.Mention} ! \n {gifLink}");
	}
}