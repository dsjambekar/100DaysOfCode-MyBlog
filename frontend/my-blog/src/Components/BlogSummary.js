import Card from "react-bootstrap/Card";

export default function BlogSummary() {
	return (
		<>
			{/* <div className="blog-summary text-left">
				<h3>
					Blog Title
					<small>Author and Date</small>
				</h3>
				<div>
					It is a long established fact that a reader will be
					distracted by the readable content of a page when looking at
					its layout. The point of using Lorem Ipsum is that it has a
					more-or-less normal distribution of letters, as opposed to
					using 'Content here, content here', making it look like
					readable English. Many desktop publishing packages and web
					page editors now use Lorem Ipsum as their default model
					text, and a search for 'lorem ipsum' will uncover many web
					sites still in their infancy. Various versions have evolved
					over the years, sometimes by accident, sometimes on purpose
					(injected humour and the like).
				</div>
			</div> */}

			<Card style={{ textAlign: "left" }}>
				<Card.Body>
					<Card.Title>Blog Title</Card.Title>
					<Card.Subtitle className="mb-2 text-muted">
						Date and Authour
					</Card.Subtitle>
					<Card.Text>
						Lorem ipsum dolor sit amet, consectetur adipiscing elit,
						sed do eiusmod tempor incididunt ut labore et dolore
						magna aliqua. Ut enim ad minim veniam, quis nostrud
						exercitation ullamco laboris nisi ut aliquip ex ea
						commodo consequat. Duis aute irure dolor in
						reprehenderit in voluptate velit esse cillum dolore eu
						fugiat nulla pariatur. Excepteur sint occaecat cupidatat
						non proident, sunt in culpa qui officia deserunt mollit
						anim id est laborum
					</Card.Text>
					<Card.Link href="#">Read</Card.Link>
				</Card.Body>
			</Card>
		</>
	);
}
