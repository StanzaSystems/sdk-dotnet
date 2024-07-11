FROM mcr.microsoft.com/devcontainers/base:ubuntu


RUN apt-get update && export DEBIAN_FRONTEND=noninteractive \
    && apt-get -y install --no-install-recommends \
    dotnet-sdk-6.0 \
    dotnet-sdk-8.0

COPY --from=mcr.microsoft.com/devcontainers/go:1.22-bookworm /usr/local/go/ /usr/local/go/
 
ENV PATH="/usr/local/go/bin:${PATH}"
ENV GOPATH /go
ENV PATH $GOPATH/bin:$PATH
RUN mkdir -p "$GOPATH/src" "$GOPATH/bin"
# Give vscode ownership of GOPATH
RUN chown -R vscode: /go

RUN go install github.com/fullstorydev/grpcurl/cmd/grpcurl@latest
RUN go install github.com/fullstorydev/grpcui/cmd/grpcui@latest
