// Function chainer
// Allows sequential execution of a series of asynchronous functions.
// However, note that execution of the chain as a whole is still
// asycnhronous in the context it was called from.
// To use, the chained functions MUST call Chainer.Next() upon completion!
var Chainer = {

	// Function stack of asynchronous methods
	_fnStack: [
	//		EXAMPLE:
	//		[
	//			fnFunction,
	//			mixedArguments
	//		]
	//		--- or ---
	//		fnFunction
	],

	// Chainer subchains may be disabled/enabled. This is useful if you want
	// to inhibit subchains from executing. To use in a chain, you should pass
	// Chainer.DisableSubChains as the first chain argument, and pass Chainer.EnableSubChains
	// as the last chain argument. For example:
	// Chainer.Do( Chainer.DisableSubChains, MyObject.MyFunction, MyObject.MyFunction2, Chainer.EnableSubChains);
	// You may also use this outside of a chain to inhibit any chains in a function
	// from executing. For example:
	// Chainer.DisableSubChains();  MyObject.Myfunction();  Chainer.EnableSubChains();
	_blnEnableSubChains: true,

	// Asynchronous methods need to call this when complete
	Next: function()
	{
		// execute next method in stack
		Chainer._do();
	},

	DisableSubChains: function()
	{
		Chainer._blnEnableSubChains = false;
		Chainer.Next();
	},

	EnableSubChains: function()
	{
		Chainer._blnEnableSubChains = true;
		Chainer.Next();
	},

	// execute next method in stack
	_do: function()
	{
		if (this._fnStack.length == 0)
		{
			return;
		}

		var mixedMethod = this._fnStack.pop();

		if (mixedMethod instanceof Array)
		{
			// Use null to indicate global scope. This means we assume scope
			// has already been bound to the method using function.bind().
			if (mixedMethod[1] instanceof Array)
			{
				mixedMethod[0].apply(null, mixedMethod[1]);
			}
			else
			{
				mixedMethod[0].apply(null, [mixedMethod[1]]);
			}
		}
		else
		{
			mixedMethod();
		}
	},

	// Creates a method chain and executes first method in the chain
	Do: function()
	{
		if (arguments.length == 0 || Chainer._blnEnableSubChains == false)
		{
			return;
		}

		// add to stack in reverse order
		for (var i = arguments.length - 1; i >= 0; i--)
		{
			this._fnStack.push(arguments[i]);
		}

		// execute first method
		this._do();
	},

	// Terminate function chain execution. Methods may choose to
	// call this INSTEAD OF Chainer.Next()
	// You may also place this at the end of a chain that
	// has no other good way of clearing the stack on completion (eg with nested chains).
	Stop: function()
	{
		this._fnStack = [];

		// If subchains were disabled, re-enable them
		this._blnEnableSubChains = true;
	}
}
