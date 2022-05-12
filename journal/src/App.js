import logo from "./logo.svg";
import "./App.css";
import data from "./journal";
import Page from "./components/Page";

function App() {
	let pages = data;
	let content = pages.map((x) => <Page page={x} />);

	return (
		<div className="App">
			<header className="App-header">#100DaysOfCode</header>
			<div className="container">{content}</div>
		</div>
	);
}

export default App;
