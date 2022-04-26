import "./App.css";
import React, { useState } from "react";

import { ThemeProvider } from "styled-components";
import { GlobalStyles } from "./Theme-Components/globalStyles";
import { lightTheme, darkTheme } from "./Theme-Components/Themes";
import Toggle from "./Theme-Components/Toggler";

import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import Container from "react-bootstrap/Container";
import Button from "react-bootstrap/Button";
import BlogSummary from "./Components/BlogSummary";

function App() {
	// const [theme, setTheme] = useState("App light");

	const [theme, setTheme] = useState("light");
	const themeToggler = () => {
		theme === "light" ? setTheme("dark") : setTheme("light");
	};

	function changeTheme() {
		if (theme === "App light") setTheme("App dark");
		else setTheme("App light");
	}

	return (
		<ThemeProvider theme={theme === "light" ? lightTheme : darkTheme}>
			<div>
				<GlobalStyles />
				<Navbar bg="light" variant="light">
					<Container>
						<Navbar.Brand href="#home">Dhanashree</Navbar.Brand>
						<Nav className="me-auto">
							<Nav.Link href="#features">Personal</Nav.Link>
							<Nav.Link href="#pricing">Technical</Nav.Link>
						</Nav>
						<Navbar.Collapse className="justify-content-end">
							<Button onClick={themeToggler}>Toggle</Button>
							<Toggle theme={theme} toggleTheme={themeToggler} />
						</Navbar.Collapse>
					</Container>
				</Navbar>
				<div>
					<Container>
						<BlogSummary />
						<BlogSummary />
						<BlogSummary />
						<BlogSummary />
						<BlogSummary />
					</Container>
				</div>
			</div>
		</ThemeProvider>
	);
}

export default App;
