using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using YumeChan.PluginBase.Tools;

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
[Group("love"), Description("Sends a random love gif")]
public class LoveCommandGroup : BaseCommandModule
{
	/*
	 * When defining a command, your method must follow the following constraints:
	 *   - Must be public, non-static, and well defined
	 *   - Must have a [Command] attribute
	 *   - Must contain a first parameter of type CommandContext
	 */

	private IWritableConfiguration _config;

	public LoveCommandGroup(IJsonConfigProvider<PluginManifest> configProvider)
	{
		_config = configProvider.GetConfiguration("love.json");
	}

	/// <summary>
	/// A simple echo command which will respond with the message sent.
	/// </summary>
	/// <remarks>
	/// Invoked using "==sample ping echo &lt;message&gt;"
	/// </remarks>
	[GroupCommand, Description("construction of answer")]
	public async Task LoveAsync(CommandContext ctx, [RemainingText] DiscordUser user)
	{
		//step 1 : takes a random gif link for love out of list
		//step 2 : constructs message in "Author loves User "random selected link""
		//step 3 : sends message


		List<string> gifList = _config.GetValue<List<string>>("gifList");


		Random r = new Random();

		int idx = r.Next(gifList.Count);

		string gifLink = gifList[idx];

		await ctx.RespondAsync($"{ctx.User.Mention} loves {user.Mention} ! ❤️ \n {gifLink}");
	}
}
