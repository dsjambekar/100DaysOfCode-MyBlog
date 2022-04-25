import logo from "./logo.svg";
import "./App.css";
import Button from "react-bootstrap/Button";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import Container from "react-bootstrap/Container";

function App() {
	return (
		<div className="App">
			<Navbar bg="light" variant="light">
				<Container>
					<Navbar.Brand href="#home">Navbar</Navbar.Brand>
					<Nav className="me-auto">
						<Nav.Link href="#home">Home</Nav.Link>
						<Nav.Link href="#features">Personal</Nav.Link>
						<Nav.Link href="#pricing">Technical</Nav.Link>
					</Nav>
				</Container>
			</Navbar>
		</div>
	);
}

export default App;
